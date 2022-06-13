import React from 'react';
import { Button, Nav, Navbar, Container, NavDropdown } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';

export default function L_Navibar() {
  return (
    <>
      <Navbar collapseOnSelect expand='lg' bg='primary' variant='dark'>
        <Container>
          <Navbar.Brand className='navbar-brand d-fles align-items-center text-light'>
            Ремонт телефонов Ifix
          </Navbar.Brand>
          <Navbar.Toggle aria-controls='responsive-navbar-nav'></Navbar.Toggle>
          <Navbar.Collapse id='responsive-navbar-nav'>
            <Nav className='me-auto'>
              <Nav.Link>Главная страница</Nav.Link>
              <Nav.Link>Услуги</Nav.Link>
              <Nav.Link>Личный кабинет</Nav.Link>
            </Nav>
              <Button variant='primary'>
                <i className='bi-person-circle text-light' style={{ fontSize: 20 }}></i>
              </Button>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  );
}
