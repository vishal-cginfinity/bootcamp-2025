import requests
from bs4 import BeautifulSoup
import time
import pandas as pd
 
print("Script started... ")
 
all_quotes_data = []
 
base_url = "http://quotes.toscrape.com"
current_url = "/"
 
headers = {
    'User-Agent': 'My-Scraping-Bot-v1.0 (for-academic-project)'
}
 
while current_url:
    full_url = base_url + current_url
    print(f"Now scraping: {full_url}")
 
    try:
        response = requests.get(full_url, headers=headers)
        
        if response.status_code == 200:
            soup = BeautifulSoup(response.text, 'html.parser')
            quotes = soup.find_all('div', class_='quote')
            
            if not quotes:
                break 
 
          
            for quote in quotes:
                text = quote.find('span', class_='text').get_text(strip=True)

                author = quote.find('small', class_='author').get_text(strip=True)

                tags_list = []
                tags = quote.find_all('a', class_='tag')
                for tag in tags:
                    tags_list.append(tag.get_text(strip=True))

                all_quotes_data.append({
                    'quote': text,
                    'author': author,
                    'tags': ", ".join(tags_list)
                })
 
            next_button = soup.find('li', class_='next')
            if next_button:
                current_url = next_button.find('a')['href']
            else:
                current_url = None 
        
        else:
            print(f"Error: Received status code {response.status_code}")
            break
 
    except requests.exceptions.RequestException as e:
        print(f"An error occurred during the request: {e}")
        break
 

    print("Waiting 1 second before next request...")
    time.sleep(1) 
 
print(f"\nScraping complete! Found {len(all_quotes_data)} quotes.")

if all_quotes_data:
    df = pd.DataFrame(all_quotes_data)

    print("\nApplying data masking to author names...")

    def mask_name(name):
        if not isinstance(name, str) or len(name) == 0:
            return ""

        return name[0] + '*' * (len(name) - 1)

    df['masked_author'] = df['author'].apply(mask_name)
 
    print("\n--- DataFrame with Masked Data (Top 5) ---")
    print(df[['quote', 'author', 'masked_author']].head())
 
 
    df.to_csv('quotes_masked.csv', index=False, encoding='utf-8')
    print("\nSuccessfully saved masked data to 'quotes_masked.csv'")
 
else:
    print("No data was scraped, so no files were saved.")
 
print("Script finished.")