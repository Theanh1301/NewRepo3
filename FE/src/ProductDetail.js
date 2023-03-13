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

  return (
    <div>
      <h1>{product.productName}</h1>
      <h3>Price: {VND.format(product.unitPrice)}</h3>
      <h3>{product.image}</h3>
      <h3>{product.details}</h3>
      <button onClick={addToCart}>Add to Cart</button>
    </div>
  );
}

export default ProductDetail;
