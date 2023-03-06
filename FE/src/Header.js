import Nav from 'react-bootstrap/Nav';
import { Routes, Route} from 'react-router-dom';
import Signin from './Signin';
import HomePage from './Home';
import Products from './Products';


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
            <Nav.Link href="/Products">Products</Nav.Link>
        </Nav.Item>
        </Nav>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/Signin' element={<Signin />} />
          <Route path='/Products' element={<Products />} />
        </Routes>
    </div>
  );
}

export default Header;