import uuid
from pathlib import Path
import requests
import boto3
from pymongo import MongoClient

# MiniO
ENDPOINT = "http://localhost:9000"
ACCESS_KEY = "root"
SECRET_KEY = "password"
BUCKET = "bird-audio"

s3 = boto3.client(
    "s3",
    endpoint_url = ENDPOINT,
    aws_access_key_id = ACCESS_KEY,
    aws_secret_access_key = SECRET_KEY
)

buckets = s3.list_buckets()
bucket_names = []
for bucket in buckets["Buckets"]:
    bucket_names.append(bucket["Name"])


if BUCKET not in bucket_names:
    s3.create_bucket(Bucket=BUCKET)
    print(f"bucket {BUCKET} created")

else:
    print(f"bucket {BUCKET} already exists")


AUDIO_DIR = Path("recordings")
LOCATION = "Zagreb"
CLASSIFY_URL = "https://aves.regoch.net/api/classify"


# Mongo
CONNECTION_STRING = "mongodb://root:password@localhost:27017"
print("opening mongoDB")
client = MongoClient(CONNECTION_STRING)

db_name = "birdsdb"
birds_db = client[db_name]
recordings_collection = birds_db["recordings"]
classifications_collection = birds_db["classifications"]


for filepath in AUDIO_DIR.glob("*.mp3"):
    
    print(f"uploading {filepath.name}")

    object_name = str(uuid.uuid4())
    s3.upload_file(str(filepath),BUCKET,object_name)

    recording = recordings_collection.insert_one({
        "filename": filepath.name,
        "location": LOCATION,
        "minio_name": object_name
    })
    recording_id = recording.inserted_id

    print(f"uploaded: {filepath.name} -> {object_name}")

    print(f"classifying: {filepath.name}")
    with open(filepath,'rb') as f:
        files = {"file": f}
        response = requests.post(CLASSIFY_URL,files=files)


    classification = response.json()
    for detection in classification["results"]:
        classifications_collection.insert_one({
            "recording_id":recording_id,
            "common_name": detection["common_name"],
            "scientific_name": detection["scientific_name"],
            "start_time": detection["start_time"],
            "end_time": detection["end_time"],
            "confidence": detection["confidence"],
            "label": detection["label"]
        })

    print(f"classifed: {filepath.name}, {len(classification['results'])} detections stored")
