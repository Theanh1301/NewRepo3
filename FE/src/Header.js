
import { Routes, Route} from 'react-router-dom';
import Signin from './Signin';
import HomePage from './Home';
import { Nav } from 'react-bootstrap';
import Signup from './Signup';


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
        </Nav>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/Signin' element={<Signin />} />       
          <Route path='/Signup' element={<Signup />} />       
        </Routes>
    </div>
  );
}

export default Header;