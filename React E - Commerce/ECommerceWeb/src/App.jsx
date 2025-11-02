import React, { useState, useEffect } from 'react';
 
const API_BASE_URL = 'http://localhost:5299';

export default function App() {
  const [products, setProducts] = useState([]);
  const [categories, setCategories] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [selectedCategory, setSelectedCategory] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    async function fetchData() {
      setLoading(true);
      setError(null);
 
      const url = new URL(`${API_BASE_URL}/api/products`);
      if (searchTerm) {
        url.searchParams.append('search', searchTerm);
      }
      if (selectedCategory) {
        url.searchParams.append('categoryId', selectedCategory);
      }
 
      try {
        const response = await fetch(url.toString());
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        setProducts(data);
      } catch (e) {
        let errorMessage = e.message;
        if (e instanceof TypeError) {
          errorMessage = "Failed to connect to the API. Is your backend server running?";
        }
        setError(errorMessage);
        console.error("Failed to fetch products:", e);
      } finally {
        setLoading(false);
      }
    }
 
    async function fetchCategories() {
      try {
        const response = await fetch(`${API_BASE_URL}/api/categories`);
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        setCategories(data);
      } catch (e) {
        console.error("Failed to fetch categories:", e);
      }
    }
 
    fetchData(); 
    if (categories.length === 0) {
      fetchCategories(); 
    }
  }, [searchTerm, selectedCategory]); 
 
  const handleClearFilters = () => {
    setSearchTerm('');
    setSelectedCategory(null);
  };
 
  return (
    <div className="app-container">
      <Header
        searchTerm={searchTerm}
        onSearchChange={(e) => setSearchTerm(e.target.value)}
      />
 
      <div className="main-layout">
        <Sidebar
          categories={categories}
          selectedCategory={selectedCategory}
          onCategorySelect={setSelectedCategory}
          onClearFilters={handleClearFilters}
        />
 
        <main className="main-content">
          <ProductGrid
            products={products}
            loading={loading}
            error={error}
          />
        </main>
      </div>
    </div>
  );
}
 

function Header({ searchTerm, onSearchChange }) {
  return (
    <header className="header">
      <div className="header-content">
        <div>
          <h1 className="header-logo">ShopSphere</h1>
        </div>
 
        <div className="header-search">
          <input
            type="search"
            value={searchTerm}
            onChange={onSearchChange}
            placeholder="Search for products..."
            className="search-input"
          />
        </div>
 
        <nav className="header-nav">
          <button className="nav-button">
            Sign In
          </button>
          <button className="nav-button nav-button-primary">
            Sign Up
          </button>
          <button className="nav-button cart-button" title="Cart">
            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor">
              <path strokeLinecap="round" strokeLinejoin="round" d="M2.25 3h1.386c.51 0 .955.343 1.087.835l.383 1.437M7.5 14.25a3 3 0 0 0-3 3h15.75a3 3 0 0 0-3-3H7.5Z" />
              <path strokeLinecap="round" strokeLinejoin="round" d="M15.75 1.5a.75.75 0 0 1 .75.75v1.5H18a.75.75 0 0 1 0 1.5h-1.5v1.5a.75.75 0 0 1-1.5 0v-1.5H13.5a.75.75 0 0 1 0-1.5h1.5v-1.5a.75.75 0 0 1 .75-.75Zm-7.5 3-1.036 6.219a.75.75 0 0 0 .741.835h10.02a.75.75 0 0 0 .74-.835L18 4.5H8.25Z" />
            </svg>
          </button>
        </nav>
      </div>
    </header>
  );
}
 

function Sidebar({ categories, selectedCategory, onCategorySelect, onClearFilters }) {
  return (
    <aside className="sidebar">
      <h2 className="sidebar-title">Categories</h2>
      <ul className="sidebar-list">
        <li>
          <button
            onClick={onClearFilters}
            className={`sidebar-button ${!selectedCategory ? 'sidebar-button-active' : ''}`}
          >
            All Products
          </button>
        </li>
        {categories.map((category) => (
          <li key={category.categoryId}>
            <button
              onClick={() => onCategorySelect(category.categoryId)}
              className={`sidebar-button ${selectedCategory === category.categoryId ? 'sidebar-button-active' : ''}`}
            >
              {category.name}
            </button>
          </li>
        ))}
      </ul>
    </aside>
  );
}
 
function ProductGrid({ products, loading, error }) {
  if (loading) {
    return (
      <div className="product-grid">
        {[...Array(8)].map((_, i) => <ProductSkeleton key={i} />)}
      </div>
    );
  }
 
  if (error) {
    return <div className="error-message">
      <strong>Error:</strong> {error}
    </div>;
  }
 
  if (products.length === 0) {
    return <div className="text-center text-gray-500 py-10">
      <h3 className="text-xl font-semibold">No products found.</h3>
    </div>;
  }
 
  return (
    <div className="product-grid">
      {products.map((product) => (
        <ProductCard key={product.productId} product={product} />
      ))}
    </div>
  );
}
 
function ProductCard({ product }) {
  const formattedPrice = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD',
  }).format(product.price);
 
  return (
    <div className="product-card">
      <div className="product-card-image-wrapper">
        <img
          src={product.imageUrl}
          alt={product.name}
          className="product-card-image"
          onError={(e) => { e.target.src = `https://placehold.co/600x400/EEE/31343C?text=${product.name.replace(' ', '+')}` }}
        />
      </div>
      <div className="product-card-content">
        <span className="product-card-category">{product.category?.name || 'Uncategorized'}</span>
        <h3 className="product-card-title" title={product.name}>
          {product.name}
        </h3>
        <p className="product-card-description" title={product.description}>
          {product.description}
        </p>
        <div className="product-card-footer">
          <span className="product-card-price">{formattedPrice}</span>
          <button className="buy-button">
            Buy Now
          </button>
        </div>
      </div>
    </div>
  );
}

function ProductSkeleton() {
  return (
    <div className="loading-skeleton">
      <div className="skeleton-image"></div>
      <div className="skeleton-content">
        <div className="skeleton-line skeleton-line-short"></div>
        <div className="skeleton-line skeleton-line-medium"></div>
        <div className="skeleton-line skeleton-line-long"></div>
        <div className="skeleton-line skeleton-line-long" style={{ width: '80%' }}></div>
        <div className="skeleton-footer">
          <div className="skeleton-line skeleton-price"></div>
          <div className="skeleton-line skeleton-button"></div>
        </div>
      </div>
    </div>
  );
}