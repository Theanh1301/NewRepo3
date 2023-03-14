import React, { useState, useEffect } from "react";

function CategoryList() {
  const [category, setCategorys] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7264/api/Categories")
      .then((response) => response.json())
      .then((data) => setCategorys(data));
  }, []);

  return (
    <div>
      <h1>Categories List</h1>
      <table border="1" width="100" >
            {category.map((category) => (
                <tr>
                    <td><a href={`/Category/${category.categoryId}`}>{category.categoryName}</a></td>
                </tr>
            ))}
      </table>
      
    </div>
  );
}

export default CategoryList;
