import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import { Button, Nav, Navbar, Container, NavDropdown } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Link } from 'react-router-dom';
import LForm from '../usercabinet/LForm';

export default function LNavbar() {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
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
              <Nav.Link disabled>Услуги</Nav.Link>
              <Nav.Link disabled>Личный кабинет</Nav.Link>
            </Nav>
            <Nav>
              {/* <Link to="/login">
                    <Button variant='light' className='me-2'>Войти</Button>
                </Link>                */}
              <Button variant='light' className='me-2' onClick={handleShow}>
                Войти
              </Button>
              <Link to='/register'>
                <Button variant='light'>Зарегистрироваться</Button>
              </Link>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <>
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
          </Modal.Header>
          <Modal.Body >
            <LForm/>
          </Modal.Body>
        </Modal>
      </>
    </>
  );
}
