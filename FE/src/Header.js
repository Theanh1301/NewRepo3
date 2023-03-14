
import { Routes, Route} from 'react-router-dom';
import Signin from './Signin';
import HomePage from './Home';
import { Nav } from 'react-bootstrap';
import Signup from './Signup';
import ProductDetail from './ProductDetail'
import ProductList from './ProductList';
import CategoryList from './CategoryList';
import ProductByCategoryId from './ProductByCategoryId';
function Header() {
  return (
    <div>
        <Nav defaultActiveKey="/" as="ul">
        <Nav.Item as="li">
            <Nav.Link href="/">Home Page</Nav.Link>
        </Nav.Item>
        <Nav.Item as="li">
            <Nav.Link href="/Signin">Signin</Nav.Link>
        </Nav.Item>
        <Nav.Item as="li">
            <Nav.Link href="/Signup">Signup</Nav.Link>
        </Nav.Item>
        <Nav.Item as="li">
            <Nav.Link href="/ProductList">ProductList</Nav.Link>
        </Nav.Item>
        <Nav.Item as="li">
            <Nav.Link href="/CategoryList">CategoryList</Nav.Link>
        </Nav.Item>
        </Nav>

        <div>-------------------------------------</div>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/Signin' element={<Signin />} />       
          <Route path='/Signup' element={<Signup />} /> 
          <Route path='/ProductList' element={<ProductList />} /> 
          <Route path='/Product/:id' element={<ProductDetail />} />  
          <Route path='/CategoryList' element={<CategoryList />} />      
          <Route path='/Category/:id' element={<ProductByCategoryId />} />    
        </Routes>
    </div>
  );
}

export default Header;