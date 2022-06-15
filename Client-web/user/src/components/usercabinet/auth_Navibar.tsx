import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import { Button, Nav, Navbar, Container, NavDropdown } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { Link } from 'react-router-dom';
import UserCabinet from './UserCabinet';

export default function L_Navibar() {
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
              <Nav.Link>
                <Link to="/home/registred" className='text-light'>Главная страница</Link>
              </Nav.Link>
              <Nav.Link>
                <Link to="/usercabinet" className='text-light'>Личный кабинет</Link>
              </Nav.Link>
              <Nav.Link disabled>Услуги</Nav.Link>
              {/* <Nav.Link href="/home/registred">Главная страница</Nav.Link>
              <Nav.Link disabled>Услуги</Nav.Link>
              <Nav.Link href="/usercabinet">Личный кабинет</Nav.Link> */}
            </Nav>
            <Button variant='primary' onClick={handleShow}>
              <i className='bi-person-circle text-light' style={{ fontSize: 20 }}></i>
            </Button>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <>
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Предупреждение</Modal.Title>
          </Modal.Header>
          <Modal.Body>Вы хотите выйти из аккаунта?</Modal.Body>
          <Modal.Footer>
            <Link to='/'>
              <Button variant='secondary' onClick={handleClose}>
                Выйти
              </Button>
            </Link>
            <Button variant='primary' onClick={handleClose}>
              Отмена
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    </>
  );
}
