import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

const VND = new Intl.NumberFormat('vi-VN', {
    style: 'currency',
    currency: 'VND',
  });

function ProductByCategoryId() {
  const { id } = useParams();
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetch(`https://localhost:7264/api/Products/products/category/${id}`)
      .then((response) => response.json())
      .then((data) => setProducts(data));
  }, [id]);

  if (!products) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <table border="1" width="500">
            <tr>
                <th>Product Name</th>
                <th>Price</th>
                <th>Image</th>
                <th>Detail</th>
            </tr>
            {products.map((product) => (
                <tr>
                    <td><a href={`/Product/${product.productId}`}>{product.productName}</a></td>
                    <td>{product.image}</td>
                    <td>{VND.format(product.unitPrice)}</td>
                    <td>{product.details}</td>
                </tr>
            ))}
      </table>
    </div>
  );
}

export default ProductByCategoryId;
