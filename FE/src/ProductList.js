import React, { useState, useEffect } from "react";
import ReactPaginate from 'react-paginate';
import './pagination.css';

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

  //table
  function Items({ currentItems }) {
    return (
      <>
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
              {currentItems && currentItems.map((item) => (
                <tr key={item.productId}>
                  <td><a href={`/Product/${item.productId}`}>{item.productName}</a></td>
                  <td>{item.image}</td>
                  <td>{VND.format(item.unitPrice)}</td>
                  <td>{item.unitInStock}</td>
                  <td>{item.categoryName}</td>
                  <td>{item.manufacturer}</td>
                  <td>{item.saler}</td>
                  <td><button style={{
                    backgroundColor: 'pink', borderRadius: '8px'
                    , border: '2px solid #000080', color: 'red', fontWeight: 'bold'
                  }}>Add</button></td>
                </tr>
              ))}
            </tbody>
          </table>
          <br />
        </div>
      </>
    );
  }

  function PaginatedItems({ itemsPerPage }) {
    const [itemOffset, setItemOffset] = useState(0);
    const endOffset = itemOffset + itemsPerPage;
    console.log(`Loading items from ${itemOffset} to ${endOffset}`);
    const currentItems = products.slice(itemOffset, endOffset);
    const pageCount = Math.ceil(products.length / itemsPerPage);

    const handlePageClick = (event) => {
      const newOffset = (event.selected * itemsPerPage) % products.length;
      console.log(
        `User requested page number ${event.selected}, which is offset ${newOffset}`
      );
      setItemOffset(newOffset);
    };

    return (
      <div >
        <Items currentItems={currentItems} />
        <div className="pagination">
          <ReactPaginate
            nextLabel="next >"
            onPageChange={handlePageClick}
            pageRangeDisplayed={3}
            marginPagesDisplayed={2}
            pageCount={pageCount}
            previousLabel="< previous"
            pageClassName="page-item"
            pageLinkClassName="page-link"
            previousClassName="page-item"
            previousLinkClassName="page-link"
            nextClassName="page-item"
            nextLinkClassName="page-link"
            breakLabel="..."
            breakClassName="page-item"
            breakLinkClassName="page-link"
            containerClassName="pagination"
            activeClassName="active"
            renderOnZeroPageCount={null}
          />
        </div>

      </div>
    );
  }


  return (
    <div>

      <PaginatedItems itemsPerPage={3} />

    </div>
  );
}

export default ProductList;
