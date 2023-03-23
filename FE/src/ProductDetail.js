import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

const VND = new Intl.NumberFormat('vi-VN', {
    style: 'currency',
    currency: 'VND',
  });

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
    if(e.target.files){
      setFile(e.target.files[0])
      console.log('attacth success')
    }
  }

  const uploadFile = () => {
    fetch("https://localhost:7264/api/Products/products/upload", {
      method: 'POST',
      body: file,
      headers: {
        'content-type':file.type,
        'content-length': `${file.size}`
      }
    }).then((res) => {
      res.json()
    }).then((data)=> console.log(data))
  }

  return (
    <div>
      <h1>{product.productName}</h1>
      <h3>Price: {VND.format(product.unitPrice)}</h3>
      <h3>{product.image}</h3>
      <h3>{product.details}</h3>
      <button onClick={addToCart}>Add to Cart</button>

      <input type="file" name="File" id="File_Upload" onChange={attachFile}></input>
      <button onClick={uploadFile}>Upload</button>
    </div>
  );
}

export default ProductDetail;
