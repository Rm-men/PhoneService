import React from 'react';
import { Button, Nav, Navbar,Container,NavDropdown } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

export default function LNavbar(){
    return(
<>
    <Navbar collapseOnSelect expand="lg" bg="primary" variant = "dark" >
        <Container>
        <Navbar.Brand className="navbar-brand d-fles align-items-center text-light">Ремонт телефонов Ifix</Navbar.Brand>
        <Navbar.Toggle aria-controls="responsive-navbar-nav"></Navbar.Toggle>
        <Navbar.Collapse id = "responsive-navbar-nav">
            <Nav className="me-auto">
                <Nav.Link>Главная страница</Nav.Link>
                <Nav.Link>Услуги</Nav.Link>
                <Nav.Link>Личный кабинет</Nav.Link>
            </Nav>
            <Nav >
                <Button variant='light' className='me-2'>Войти</Button>
                <Button variant='light'>Зарегистрироваться</Button>
            </Nav>
        </Navbar.Collapse>
        </Container>
    </Navbar>
</>
)}
