#RAG-based Chatbot (Aurora Skies Airways)
 
This project is a Retrieval-Augmented Generation (RAG) chatbot for Aurora Skies Airways, built for an assignment. It uses a provided FAQ dataset to answer customer queries accurately and is grounded to prevent hallucinations.
 
## Features
* **Retrieval-Augmented Generation (RAG):** Retrieves relevant FAQs before generating an answer.
* **Grounding Strategy:** Uses a specific prompt to force the LLM (Google Gemini) to answer *only* from the provided context.
* **Interactive UI:** Built with Streamlit for an easy-to-use chat interface.
* **Tech Stack:** LangChain, Google Gemini, FAISS, Streamlit.
  
## How to Run Locally
 
1.  **Clone the Repository:**
    ```bash
    git clone <your-repository-url-here>
    cd <your-repo-name>
    ```
 
2.  **Set Up Environment:**
    ```bash
    # Create and activate a virtual environment
    python -m venv venv
    source venv/bin/activate 
    
    # Install dependencies
    pip install -r requirements.txt
    ```
 
3.  **Add API Key:**
    * Create a file named `.env` in the project root.
    * Add your Google Gemini API key to it:
        ```
        GOOGLE_API_KEY="your-key-here"
        ```
 
4.  **Ingest Data (Run Once):**
    * This script creates the `faiss_index` vector store from the CSV.
    ```bash
    python ingest.py
    ```
 
5.  **Run the App:**
    ```bash
    streamlit run app.py
    ```
* The application will open in your web browser.