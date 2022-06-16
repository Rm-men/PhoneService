import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import Links from '../Links';

import sha256 from "sha256";
import {LoginModel} from '../../models/RequestModels';
import AuthService from '../../redux/services/ServAuth';
import {useDispatch, useSelector} from "react-redux";
import {useNavigate} from 'react-router-dom';
import {AppDispatch, RootState} from "../../redux/store";

import { Button, Container, Form, FormLabel, InputGroup, Row, Col } from 'react-bootstrap';
export default function LForm(show) {
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
      // handleClose();
      navigate(Links.home);
		})
	};
  const navigate = useNavigate();
  // const user = useSelector((state: RootState) => state);
  // const dispatch = useDispatch<AppDispatch>();

  return (
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
  );
}
