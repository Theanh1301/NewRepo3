import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

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
      <table border="1" width="600" >
        <thead>
            <tr>
                <th width="50%">Tên sản phẩm</th>
                <th width="25%">Ảnh</th>
                <th>Giá</th>
            </tr>
        </thead>
        <tbody>
            {products.map((product) => (
                <tr>
                    <td><a href={`/product/${product.productId}`}>{product.productName}</a></td>
                    <td>{product.image}</td>
                    <td>{VND.format(product.unitPrice)}</td>
                </tr>
            ))}
        </tbody>
      </table>
      
    </div>
  );
}

export default ProductList;
