import { Link } from 'react-router-dom';
import Links from '../Links';

import React, { useState } from 'react';
import sha256 from 'sha256';
import { LoginModel } from '../../models/RequestModels';
import AuthService from '../../redux/services/ServAuth';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { AppDispatch, RootState } from '../../redux/store';

import { Button, Container, Form, FormLabel, InputGroup, Row, Col } from 'react-bootstrap';
export default function LForm(show) {
  interface State {
    email: string;
    password: string;
  }
  const [validated, setValidated] = useState(false); //тумблер подсветки валидации
  const [values, setValues] = useState<State>({
    email: '',
    password: '',
  });
  const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
    setValues({ ...values, [prop]: event.target.value.trim() });
  };
  const onClick = (event: any) => {
    console.log (values.email);
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      return;
    } else setValidated(true); // активация подсветки валидации
    if (values.email === '' || values.password === '') {
      return;
    }
    const data: LoginModel = {
      email: values.email,
      password: sha256(values.password),
    };
    console.log (data.email);

    AuthService.login(data).then((res) => {
      console.log (values.email);
      dispatch(res);
      navigate(Links.home);
    });
  };
  const navigate = useNavigate();
  const user = useSelector((state: RootState) => state);
  const dispatch = useDispatch<AppDispatch>();

  return (
    <Container>
      <Row className='justify-content-md-center'>
        <Col md='auto'>
          <div className='register-form'>
            <div className='mb-5'>
              <h1>Авторизация</h1>
            </div>
            <Form noValidate validated={validated}>
              <Form.Group className='mb-3' controlId='formBasicEmail'>
                <Form.Label>Email </Form.Label>
                <Form.Control
                  required
                  type='email'
                  placeholder='Введите email'
                  value={values.email}
                  onChange={handleChange('email')}
                />
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPassword'>
                <Form.Label>Пароль</Form.Label>
                <Form.Control
                  required
                  type='password'
                  placeholder='Введите пароль'
                  value={values.password}
                  onChange={handleChange('password')}
                />
              </Form.Group>
              {/* <Form.Group className='mb-3' controlId='formBasicCheckbox'>
                <Form.Check type='checkbox' label='Запомнить меня' />
              </Form.Group> */}
              <Button variant='primary' onClick={onClick}>
                Войти
              </Button>
            </Form>
            <p className='small my-4 text-center'>
              Нет аккаунта? <Link to={Links.register}>Зарегистрируйтесь</Link>
            </p>
          </div>
        </Col>
      </Row>
    </Container>
  );
}
