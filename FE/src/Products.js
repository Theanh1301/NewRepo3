import Table from 'react-bootstrap/Table';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
function ProductsList()
{
    const [products, setProducts] = useState([]);
    useEffect(() => {
        axios.get('http://localhost:7264/api/products')
        .then(response => setProducts(response.products))
        .catch(error => console.log(error));
    }, []);
    
    return (
       <div>
            <h1>Products List</h1>
            <Table>
                <tr>
                    <th>Product Name</th>
                    <th>Price</th>
                    <th>Manufacture</th>
                    <th>Image</th>
                    <th>Detail</th>
                </tr>
            {
                products.map((item)=> {
                    <tr>
                    <td>{item.ProductName}</td>
                    <td>{item.UnitPrice}</td>
                    <td>{item.Manufacture}</td>
                    <td>{item.Image}</td>
                    <td>{item.Details}</td>
                </tr>    
                })
            }
            </Table>
       </div>
    );
}
export default ProductsList;