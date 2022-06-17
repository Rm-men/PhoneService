
import { Button, Container, Form, FormLabel, InputGroup, Row, Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Links from '../Links';

import React, { useState } from 'react';
import sha256 from "sha256";
import {RegistrationModel} from '../../models/RequestModels';
import AuthService from '../../redux/services/ServAuth';
import {useDispatch, useSelector} from "react-redux";
import {useNavigate} from 'react-router-dom';
import {AppDispatch, RootState} from "../../redux/store";

interface State {
	family: string,
	name: string,
  patronymic: string,
	phone: string,
	email: string,
	clpassword: string,
	passwordcheck: string
}

export default function RForm() {

  const user = useSelector((state: RootState) => state);
  const dispatch = useDispatch<AppDispatch>();

  const [values, setValues] = useState<State>({
		family: '',
		name: '',
    patronymic: '',
		phone: '',
		email: '',
		clpassword: '',
		passwordcheck: ''
	});

  const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
    setValues({ ...values, [prop]: event.target.value.trim() });
  };
  const handleMouseDownPassword = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.preventDefault();
  };

  const onClick = (event: any) => {
    if(values.clpassword !== values.passwordcheck){
      alert("Пароли не совпадают, повторите попытку.");
      return;
    } 
    const data : RegistrationModel = {
      family: values.family,
      name: values.name,
      patronymic: values.patronymic,
      phone: values.phone,
      email: values.email,
      clpassword: sha256(values.clpassword),
    }
    AuthService.register(data).then((res) => {
      dispatch(res);
      navigate(Links.usercabinet);
    })
  }
  const navigate = useNavigate();

  return (
    <Container>
      <Row className='justify-content-md-center'>
        <Col md='auto'>
          <div className='register-form'>
            <div className='mb-5'>
              <h1>Регистрация</h1>
              <p className='lead'>
                Создайте свой аккаунт для доступа к оформлению заказа на ремонт
              </p>
            </div>
            <Form>
            <Form.Group className='mb-3' controlId='formBasicFamily'>
                <Form.Label>Фамилия</Form.Label>
                <Form.Control type='family' placeholder='Введите фамилию' value={values.family} onChange={handleChange('family')}/>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicName'>
                <Form.Label>Имя</Form.Label>
                <Form.Control type='name' placeholder='Введите имя' value={values.name} onChange={handleChange('name')}/>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPatr'>
                <Form.Label>Номер телефона</Form.Label>
                <Form.Control type='phone' placeholder='Введите номер телефона' value={values.phone} onChange={handleChange('phone')}/>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPatr'>
                <Form.Label>Отчество</Form.Label>
                <Form.Control type='midle-name' placeholder='Введите отчество (если есть)' value={values.patronymic} onChange={handleChange('patronymic')}/>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicEmail'>
                <Form.Label>Email </Form.Label>
                <Form.Control type='email' placeholder='Введите email' value={values.email} onChange={handleChange('email')}/>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPassword'>
                <Form.Label>Пароль</Form.Label>
                <Form.Control type='password' placeholder='Введите пароль' value={values.clpassword} onChange={handleChange('clpassword')}/>
                <Form.Text className='text-muted'>
                  Придумайте надежный пароль
                </Form.Text>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formRetypePassword'>
                <Form.Label>Повторите пароль</Form.Label>
                <Form.Control type='password' placeholder='Повторите пароль' value={values.passwordcheck} onChange={handleChange('passwordcheck')}/>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicCheckbox'>
                <Form.Check type='checkbox' label='Запомнить меня' />
              </Form.Group>
              <Link to='/usercabinet'>
                <Button variant='primary' onClick={onClick}>
                  Зарегистрироваться
                </Button>
              </Link>
            </Form>
            <p className='small my-4 text-center'>
              Есть аккаунт? <Link to={Links.auth}>Авторизируйтесь</Link>
            </p>
          </div>
        </Col>
      </Row>
    </Container>
  );
}
