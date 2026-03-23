# 🛒 ShopEZ – E-Commerce Frontend Application

## 📌 Project Overview
ShopEZ is a fully functional frontend e-commerce web application built using modern web technologies. It allows users to browse products, view details, manage a shopping cart, and simulate a checkout process.

This project is entirely client-side and uses LocalStorage for data persistence.

---

## 🚀 Features

### 🏠 Home Page
- Hero section with modern UI
- Trending products display
- Responsive layout

### 🛍️ Products Page
- Product listing from JSON
- Search functionality
- Category filtering
- Price filtering
- Loading spinner & error handling

### 📦 Product Details
- Detailed product view
- Quantity selection (1–10)
- Add to cart functionality

### 🛒 Cart Page
- Add/remove items
- Increase/decrease quantity
- Auto total calculation
- Empty cart handling
- Checkout button disabled when cart is empty

### 💳 Checkout Page
- Form validation:
  - Name validation
  - Email validation
  - Address validation
  - Payment method validation
- Order summary display
- Cart clearing after order

### 🎉 Success Page
- Order confirmation message
- Auto redirect to home
- Modern UI with animation

---

## 🧰 Technologies Used

- HTML5
- CSS3
- JavaScript (ES6)
- Bootstrap 5
- jQuery
- LocalStorage
- JSON

---

## 📁 Project Structure
ShopEZ-Frontend
│
├── index.html
├── products.html
├── product-details.html
├── cart.html
├── checkout.html
├── success.html
│
├── css/
│ └── styles.css
│
├── js/
│ ├── products.js
│ ├── cart.js
│ ├── checkout.js
│ └── common.js
│
├── data/
│ └── products.json
│
├── images/
│
└── lib/
├── bootstrap/
└── jquery/

---

## 💡 Key Functionalities

- Dynamic product loading from JSON :contentReference[oaicite:0]{index=0}  
- Cart management using LocalStorage  
- Quantity validation (1–10 limit)  
- Error handling with `.done()` and `.fail()`  
- Responsive design using Bootstrap  
- Clean modular JavaScript architecture  

---

## 🧪 Validation & Error Handling

- Prevent empty form submission
- Validate email using regex
- Handle invalid product IDs
- Prevent cart crashes using safety checks
- Disable checkout for empty cart

---

## 🎯 Learning Outcomes

- DOM manipulation using jQuery
- State management using LocalStorage
- Responsive UI design
- Modular JavaScript structure
- Event handling and validation

---

## 📸 Screenshots
(Add screenshots here if uploading to GitHub)

---

## 🚀 How to Run

1. Download or clone the project
2. Open `index.html` in browser
3. Start exploring ShopEZ

---

## 📌 Future Enhancements

- Backend integration (Node.js / Spring Boot)
- User authentication
- Payment gateway integration
- Admin dashboard

---

## 👨‍💻 Author

**Hemanth**  
B.Tech CSE Graduate (2024)

---

## ⭐ Project Status

✅ Completed  
✅ Fully functional  
✅ Ready for evaluation  
