import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

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
//test token
const savedToken = JSON.parse(localStorage.getItem("token"));
console.log('token', savedToken);

//add to cart
function handleAddToCart(productId, quantity, userId) {
  const data = {
    "productId": productId,
    "quantity": quantity,
    "userId": userId
  };
  console.log(data)

  return fetch('https://localhost:7264/api/ShoppingCart/Add', {
    method: 'POST',
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

function ProductDetail() {
  const { id } = useParams();
  const [product, setProduct] = useState(null);

  const [cart, setCart] = useState([]);

  const [file, setFile] = useState();

  useEffect(() => {
    fetch(`https://localhost:7264/api/Products/products/${id}`)
      .then((response) => response.json())
      .then((data) => setProduct(data));
  }, [id]);

  const addToCart = () => {
    setCart([...cart, product]);
  };

  if (!product) {
    return <div>Loading...</div>;
  }

  const attachFile = (e) => {
    if (e.target.files) {
      setFile(e.target.files[0])
      console.log('attacth success')
    }
  }

  const uploadFile = () => {
    fetch("https://localhost:7264/api/Products/products/upload", {
      method: 'POST',
      body: file,
      headers: {
        'content-type': file.type,
        'content-length': `${file.size}`
      }
    }).then((res) => {
      res.json()
    }).then((data) => console.log(data))
  }

  return (
    <div>
      <h1>{product.productName}</h1>
      <h3>Price: {VND.format(product.unitPrice)}</h3>
      <h3><img src={`https://localhost:7264/images/` + product.image} height="200" /></h3>
      <h3>Detail: {product.details}</h3>
      <h3>Unit in stock: {product.unitInStock}</h3>
      <h3>Manufacturer: {product.manufacturer}</h3>
      <button onClick={ () => {
        handleAddToCart(product.productId, 1, parseInt(parseJwt(savedToken).Id))
      }
      }>Add to Cart</button>

      <br />
      <br />

      <input type="file" name="File" id="File_Upload" onChange={attachFile}></input>
      <button onClick={uploadFile}>Upload</button>
    </div>
  );
}

export default ProductDetail;
