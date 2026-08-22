import csv
from pymongo import MongoClient

CONNECTION_STRING = "mongodb://root:password@localhost:27017"
print("opening mongoDB")
client = MongoClient(CONNECTION_STRING)

db_name = "birdsdb"
birds_db = client[db_name]
species_collection = birds_db["species"]
recordings_collection = birds_db["recordings"]
classifications_collection = birds_db["classifications"]

CONFIDENCE_TRESHOLD = 0.5

positive_classifications = classifications_collection.find({
    "confidence":{"$gt": CONFIDENCE_TRESHOLD}
    })


species_count = {}
for classification in positive_classifications:
    name = classification["scientific_name"]

    if name in species_count:
        species_count[name] = species_count[name] + 1

    else:
        species_count[name] = 1

rows = []

for name, count in species_count.items():
    specie = species_collection.find_one({"canonical_name": name})

    if specie is not None:
        family = specie["family"]
        order = specie["order"]

    else:
        family = ""
        order = ""

    rows.append({
        "species_name": name,
        "observation_count": count,
        "family": family,
        "order": order
    })

with open("report.csv","w",newline="",encoding="utf-8") as f:
    writer = csv.DictWriter(f,fieldnames=["species_name","observation_count","family","order"])
    writer.writeheader()
    for row in rows:
        writer.writerow(row)

print(f"CSV generated with {len(rows)} species")