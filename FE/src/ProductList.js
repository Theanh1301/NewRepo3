import React, { useState, useEffect } from "react";

const VND = new Intl.NumberFormat('vi-VN', {
    style: 'currency',
    currency: 'VND',
});

function ProductList() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7264/api/Products")
      .then((response) => response.json())
      .then((data) => setProducts(data));
  }, []);

  return (
    <div>
      <h1>Product List</h1>
      <table border="1" width="100%" >
        <thead align="center">
            <tr>
                <th width="250">Name</th>
                <th width="200">Image</th>
                <th>Price</th>
                <th width="120">Unit In Stock</th>
                <th>Category</th>
                <th>Manufacturer</th>
                <th>Saler</th>
                <th>Add to cart</th>
            </tr>
        </thead>
        <tbody align="center">
            {products.map((product) => (
                <tr>
                    <td><a href={`/Product/${product.productId}`}>{product.productName}</a></td>
                    <td>{product.image}</td>
                    <td>{VND.format(product.unitPrice)}</td>
                    <td>{product.unitInStock}</td>
                    <td>{product.categoryName}</td>
                    <td>{product.manufacturer}</td>
                    <td>{product.saler}</td>
                    <td><button style={{backgroundColor:'pink', borderRadius: '8px'
                    , border:'2px solid #000080', color: 'red', fontWeight:'bold' } }>Add</button></td>
                </tr>
            ))}
        </tbody>
      </table>
      
    </div>
  );
}

export default ProductList;
