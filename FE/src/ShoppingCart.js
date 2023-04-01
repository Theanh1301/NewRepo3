import React, { useState, useEffect } from "react";
import { Trash3 } from 'react-bootstrap-icons';
import { Button } from 'react-bootstrap';
import "./adjust.css"

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
//remove
function handleRemoveCart(productId, userId) {
  const data = {
    "productId": productId,
    "userId": userId
  };
  console.log(data)

  return fetch('https://localhost:7264/api/ShoppingCart/RemoveAll', {
    method: 'DELETE',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(data),
  })
    .then((response) => {
      response.json()
      window.location.href = '/cart';
    })
    .then((data) => {
      console.log("Success:", data);
    })
    .catch((error) => {
      console.error("Error:", error);
    });


}
//adjust
function QuantityAdjuster(props) {

  const init = props.q;
  const productId = props.p;
  const userId = props.u;

  console.log('ban dau', productId, init, userId);
  console.log(typeof init)

  const [quantity, setQuantity] = useState(init);

  function handleIncrement() {
    setQuantity(prevQuantity => prevQuantity + 1);
  }

  function handleDecrement() {
    if (quantity > 1) {
      setQuantity(prevQuantity => prevQuantity - 1);
    }
  }

  function handleQuantityChange(event) {
    const newQuantity = Number(event.target.value);
    console.log("q new", newQuantity)
    if (newQuantity > 0) {
      setQuantity(newQuantity);
    }

  }

  useEffect(() => { // this hook will get called every time q has changed
    console.log("q new set", quantity)

    fetch('https://localhost:7264/api/ShoppingCart/ChangeQuantity', {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ productId, quantity, userId })
    })

  }, [quantity])

  return (
    <div className="quantity-adjuster">
      <button  onClick={handleDecrement}>-</button>
      <input type="number" value={quantity} onChange={handleQuantityChange} />
      <button onClick={handleIncrement}>+</button>
    </div>
  );
}

function ShoppingCart() {
  const [products, setProducts] = useState([]);

  const savedToken = JSON.parse(localStorage.getItem("token"));
  console.log('token', savedToken);

  useEffect(() => {
    fetch(`https://localhost:7264/api/ShoppingCart/ShoppingCart/${parseJwt(savedToken).Id}`, {
    })
      .then((response) => response.json())
      .then((data) => setProducts(data));
  }, []);
  //
  
  //
  return (
    <div>
      <h1>Shopping Cart</h1>
      <table border="1" width="100%">
        <thead>
          <tr>
            <td width="40%" align="left"><b>Name</b></td>
            <td width="10%" align="center"><b>Quantity</b></td>
            <td width="30%" align="right"><b>Unit Price</b></td>
            <td width="20%" align="center"><b>#</b></td>
          </tr>
        </thead>
        <tbody >
          {products && products.map((item) => (
            <tr key={item.sid}>
              <td>{item.productName}</td>
              <td>
                <QuantityAdjuster p={item.productId} q={item.quantity} u={parseInt(parseJwt(savedToken).Id)} />
              </td>
              <td align="right">{VND.format(item.totalPrice / item.quantity)}</td>
              <td align="center"><button className="btn" onClick={() => {
                handleRemoveCart(item.productId, parseInt(parseJwt(savedToken).Id))
              }}><Trash3 /></button></td>
            </tr>
          ))}
        </tbody>
      </table>
      <br />

      <table border="0" width="100%" >
        <tbody>
          <tr>
            <td width="40%" align="left"><b></b></td>
            <td width="10%" align="right"><b></b></td>
            <td width="30%" align="right" ><p style={{ fontSize: 18 }}><b>Total: {VND.format(products.reduce((total, current) => total + current.totalPrice, 0))}</b></p></td>
            <td width="20%" align="center"><b></b></td>
          </tr>
          <tr>
            <td width="40%" align="left"><b></b></td>
            <td width="10%" align="right"><b></b></td>
            <td width="30%" align="right"><Button variant="primary" size="lg">CHECKOUT</Button></td>
            <td width="20%" align="center"><b></b></td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}

export default ShoppingCart