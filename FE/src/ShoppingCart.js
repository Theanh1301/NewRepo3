import React, { useState, useEffect } from "react";

const VND = new Intl.NumberFormat('vi-VN', {
  style: 'currency',
  currency: 'VND',
});

//decode
function parseJwt(token) {
  if (!token) { return; }
  const base64Url = token.split('.')[1];
  const base64 = base64Url.replace('-', '+').replace('_', '/');
  return JSON.parse(window.atob(base64));
}

function ShoppingCart() {
  const [products, setProducts] = useState([]);

  const savedToken = JSON.parse(localStorage.getItem("token"));
  console.log('token', savedToken);

  console.log('info', parseJwt(savedToken).Username)

  useEffect(() => {
    fetch("https://localhost:7264/api/ShoppingCart/ShoppingCart/3",{
    })
      .then((response) => response.json())
      .then((data) => setProducts(data));
  }, []);

  return (
    <div>
          <h1>Shopping Cart</h1>
          <table border="1" width="100%" >
            <thead align="center">
              <tr>
                <th width="350">Name</th>
                <th width="200">Quantity</th>
                <th width="200">Price</th>
                <th width="200">#</th>
              </tr>
            </thead>
            <tbody align="center">
              {products && products.map((item) => (
                <tr key={item.productId}>
                  <td>{item.productName}</td>
                  <td>{item.quantity}</td>
                  <td>{VND.format(item.totalPrice/item.quantity)}</td>
                </tr>
              ))}
            </tbody>
          </table>
          <br />

          <table border="0" width="100%" >
            <thead align="center">
              <tr>
                <th width="350"></th>
                <th width="200"></th>
                <th width="200">Total</th>
                <th width="200"></th>
              </tr>
            </thead>
            <tbody align="center">
              <tr>
                <td></td>
                <td></td>
                <td><b>{VND.format(products.reduce((total, current) => total + current.totalPrice, 0))}</b></td>
              </tr>
            </tbody>
          </table>
        </div>
  );
}

export default ShoppingCart;
