from pprint import pprint
from pymongo import MongoClient

import requests

CONNECTION_STRING = "mongodb://root:password@localhost:27017"

url = "https://aves.regoch.net/aves.json"

print("fetching data")
response = requests.get(url)
data = response.json()

document_list = []
for item in data:
    document = {
        "key": item["key"],
        "scientific_name": item["scientificName"],
        "canonical_name": item["canonicalName"],
        "rank": item["rank"],
        "family": item["family"],
        "order": item["order"]
    }
    document_list.append(document)

# print(len(document))
# pprint(document_list)
print("data fetching finnished")


print("opening mongoDB")
client = MongoClient(CONNECTION_STRING)


db_name = "birdsdb"
birds_db = client[db_name]
species_collection = birds_db["species"]

species_collection.create_index("key",unique=True)

inserted = 0
skipped = 0

for doc in document_list:
    try:
        species_collection.insert_one(doc)
        inserted +=1

    except Exception:
        skipped +=1

print(f"inserted: {inserted}, skipped: {skipped}")
