import pandas as pd
from langchain.docstore.document import Document
from langchain.embeddings import HuggingFaceEmbeddings
from langchain.vectorstores import FAISS
import os
 
def create_vector_store():
    try:
        df = pd.read_csv("airline_faq.csv")
        print("CSV loaded successfully.")
    except FileNotFoundError:
        print("\nError: airline_faq.csv not found.")
        print("Please make sure the file is in the same directory.")
        return
 
    try:
        documents = [
            Document(
                page_content=f"Question: {row['Question']}\nAnswer: {row['Answer']}",
                metadata={"source": "faq.csv"}
            )
            for index, row in df.iterrows()
        ]
    except KeyError as e:
        print(f"\nError: Column not found: {e}")
        print("Please open ingest.py and make sure the column names (e.g., 'Question', 'Answer')")
        print("exactly match your airline_faq.csv file.")
        return
 
    print("Initializing embedding model (all-MiniLM-L6-v2)...")
    embeddings = HuggingFaceEmbeddings(model_name="all-MiniLM-L6-v2")
 
    print("Creating vector store...")
    db = FAISS.from_documents(documents, embeddings)
 
    db.save_local("faiss_index")
    print("\nVector store created and saved to 'faiss_index'.")
 
if __name__ == "__main__":
    create_vector_store()