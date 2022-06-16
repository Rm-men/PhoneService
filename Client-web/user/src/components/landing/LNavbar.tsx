import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import { Button, Container, Form, FormLabel, InputGroup, Row, Col, Nav, Navbar, Dropdown } from 'react-bootstrap';
import  UncontrolledDropdown from"react-bootstrap/Dropdown";

import 'bootstrap/dist/css/bootstrap.min.css';
import { Link } from 'react-router-dom';
import LForm from '../auth/LForm';
import Links from '../Links';

import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import { faCircleUser} from '@fortawesome/free-solid-svg-icons';

import sha256 from "sha256";
import {LoginModel} from '../../models/RequestModels';
import AuthService from '../../redux/services/ServAuth';
import {useDispatch, useSelector} from "react-redux";
import {useNavigate} from 'react-router-dom';
import {AppDispatch, RootState} from "../../redux/store";

import User from '../User';

export default function LNavbar() {
  
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    interface State {
      email: string,
      password: string
    }
    const [values, setValues] = useState<State>({
      email: '',
      password: ''
    });
    const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
      setValues({...values, [prop]: event.target.value.trim()});
    };
    const onClick = () => {
      const data: LoginModel = {
        email: values.email,
        password: sha256(values.password)
      };
      AuthService.login(data).then((res) => {
        // dispatch(res)
        handleClose();
        navigate(Links.usercabinet);
      })
    };
    const navigate = useNavigate();
    const user = useSelector((state: RootState) => state); 
    const dispatch = useDispatch<AppDispatch>(); 
  
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
              <Nav.Link href={Links.home}>Главная страница</Nav.Link>
              <Nav.Link disabled={!user.client.isAuth} href={Links.usercabinet}>Личный кабинет</Nav.Link>
              <Nav.Link disabled>Услуги</Nav.Link>
            </Nav>
            <Nav>            
              {user.client.isAuth?( // что за свойство isAuth 
             // {usered?(
              <div  className="align-items-center d-none d-md-flex">
            <UncontrolledDropdown>
              <Dropdown.Toggle className="rr pr-0 d-flex"
               style={{
              border:"0px",
              backgroundColor:"#ffffff",
              backgroundSize: "cover",
              backgroundPosition: "center top",
              }}>
                <div className="align-items-center d-flex" >
                  <div className="ml-2 d-none d-lg-block">
                    <span className="mb-0 mx-2 text-black  font-bold">
                      {user.client.client!.Namecl}
                    </span>
                  </div>
                  <span className="text-primary">
            {" "}<FontAwesomeIcon icon={faCircleUser} />{" "}
          </span>
                </div>
              </Dropdown.Toggle>
              <Dropdown.Menu className="dropdown-menu-arrow dropdown-toggle-split">
                <Dropdown.Item>
                  <i className="ni ni-single-02" />
                  <span>Мой профиль</span>
                </Dropdown.Item>
                <Dropdown.Item  onClick={()=>dispatch(AuthService.logout())} href={Links.home}>
                  <i className="ni ni-user-run" />
                  <span>Выйти</span>
                </Dropdown.Item>
              </Dropdown.Menu>
            </UncontrolledDropdown>
                      </div>
              
            ):(
              <>
              <Button variant='light' className='me-2' onClick={handleShow}>
                Войти
              </Button>
              <Link to={Links.register}>
                <Button variant='light'>Зарегистрироваться</Button>
              </Link>
              </>
            )}
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <>
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
          </Modal.Header>
          <Modal.Body >
          <Container>
      <Row className='justify-content-md-center'>
        <Col md='auto'>
          <div className='register-form'>
            <div className='mb-5'>
              <h1>Авторизация</h1>
            </div>
            <Form>
              <Form.Group className='mb-3' controlId='formBasicEmail'>
                <Form.Label>Email </Form.Label>
                <Form.Control type='email' placeholder='Введите email' value={values.email} onChange={handleChange('email')}/>
                {/* <Form.Text className='text-muted'>
            We'll never share your email with anyone else.
          </Form.Text> */}
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPassword'>
                <Form.Label>Пароль</Form.Label>
                <Form.Control type='password' placeholder='Введите пароль' value={values.password} onChange={handleChange('password')} />
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicCheckbox'>
                <Form.Check type='checkbox' label='Запомнить меня' />
              </Form.Group>
              <Button variant='primary' onClick={onClick}>
                Войти
              </Button>
            </Form>
            <p className='small my-4 text-center'>
              Нет аккаунта? <a href={Links.auth}>Зарегистрируйтесь</a>
            </p>
          </div>
        </Col>
      </Row>
    </Container>
          </Modal.Body>
        </Modal>
      </>
    </>
  );
}
