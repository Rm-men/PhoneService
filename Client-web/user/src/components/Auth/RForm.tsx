import { Button, Container, Form, FormLabel, InputGroup, Row, Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Links from '../Links';

import React, { useState } from 'react';
import sha256 from 'sha256';
import { RegistrationModel } from '../../models/RequestModels';
import AuthService from '../../redux/services/ServAuth';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { AppDispatch, RootState } from '../../redux/store';
import Page__REGISTER from './RegForm';

interface State {
  family: string;
  name: string;
  patronymic: string;
  phone: string;
  email: string;
  clpassword: string;
  passwordcheck: string;
}

export default function RForm() {
  const [validated, setValidated] = useState(false); //тумблер подсветки валидации

  const user = useSelector((state: RootState) => state);
  const dispatch = useDispatch<AppDispatch>();

  const [values, setValues] = useState<State>({
    family: '',
    name: '',
    patronymic: '',
    phone: '',
    email: '',
    clpassword: '',
    passwordcheck: '',
  });

  const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
    setValues({ ...values, [prop]: event.target.value });
  };
  const handleMouseDownPassword = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.preventDefault();
  };

  const onClick = (event: any) => {
    console.log('начало авторизации');
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      setValidated(false);
      return;
    } else setValidated(true); // активация подсветки валидации
    console.log('подсветили кнопки');
    if (
      values.passwordcheck === '' ||
      values.clpassword === '' ||
      values.email === '' ||
      values.phone === '' ||
      values.name === '' ||
      values.family === ''
    ) {
      return;
    }
    // if () return; // если форма невалидна, разворачиваем
    console.log('проверили непустоту полей');
    if (values.clpassword !== values.passwordcheck) {
      alert('Пароли не совпадают, повторите попытку.');
      return;
    }
    console.log('проверили пароли');
    const data: RegistrationModel = {
      family: values.family,
      name: values.name,
      patronymic: values.patronymic,
      phone: values.phone,
      email: values.email,
      clpassword: sha256(values.clpassword),
    };
    console.log('Начали логинить - 1');
    AuthService.register(data).then((res) => {
      console.log('Начали логинить');
      dispatch(res);
      // navigate(Links.usercabinet);
      navigate(Links.home);
    });
  };
  const navigate = useNavigate();

  return (
    <Container>
      {/* <ReactPhoneInput defaultCountry={'RU'} onChange={handleChange('phone')}/> */}

      <Page__REGISTER></Page__REGISTER>
      <Row className='justify-content-md-center'>
        <Col md='auto'>
          <div className='register-form'>
            <div className='mb-4'>
              <h1>Регистрация</h1>
              <p className='lead'>
                Создайте свой аккаунт для доступа к оформлению заказа на ремонт
              </p>
            </div>

            <Form noValidate validated={validated}>
              {' '}
              {/* флаги для валидации */}
              <Form.Group className='mb-1' controlId='formBasicFamily'>
                <Form.Label>Фамилия</Form.Label>
                <Form.Control
                  required
                  type='family'
                  placeholder='Введите фамилию'
                  value={values.family}
                  onChange={handleChange('family')}
                />
                <Form.Control.Feedback type='invalid'>
                  Пожалуйста, введите фамилию
                </Form.Control.Feedback>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicName'>
                <Form.Label>Имя</Form.Label>
                <Form.Control
                  required
                  type='name'
                  placeholder='Введите имя'
                  value={values.name}
                  onChange={handleChange('name')}
                />
                <Form.Control.Feedback type='invalid'>
                  Пожалуйста, введите имя
                </Form.Control.Feedback>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPatr'>
                <Form.Label>Отчество</Form.Label>
                <Form.Control
                  type='midle-name'
                  placeholder='Введите отчество (если есть)'
                  value={values.patronymic}
                  onChange={handleChange('patronymic')}
                />
              </Form.Group>
              <Form.Group controlId='formBasicPhNumb'>
                {/* <Form.Group as={Col} md='4' controlId='formBasicPhNumb'>  - фикисрованная длина*/}
                <Form.Label>Номер телефона</Form.Label>
                <InputGroup hasValidation>
                  <InputGroup.Text id='inputGroupPrepend'>+7</InputGroup.Text>
                  <Form.Control
                    // type='number' появляются стрелочки для изменения числа, для номера оно не надо
                    type='tel'
                    placeholder='Введите номер телефона'
                    required
                    value={values.phone}
                    onChange={handleChange('phone')}
                  />
                  <Form.Control.Feedback type='invalid'>
                    Пожалуйста, введите ваш номер телефона
                  </Form.Control.Feedback>
                </InputGroup>
              </Form.Group>
              <Form.Group controlId='validationCustomUsername'>
                <Form.Label>Email</Form.Label>
                <InputGroup hasValidation>
                  <InputGroup.Text id='inputGroupPrepend'>@</InputGroup.Text>
                  <Form.Control
                    type='email'
                    placeholder='Введите Email'
                    aria-describedby='inputGroupPrepend'
                    required
                    value={values.email}
                    onChange={handleChange('email')}
                  />
                  <Form.Control.Feedback type='invalid'>
                    Пожалуйста, введите ваш Email
                  </Form.Control.Feedback>
                </InputGroup>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPassword'>
                <Form.Label>Пароль</Form.Label>
                <Form.Control
                  required
                  type='password'
                  placeholder='Введите пароль'
                  value={values.clpassword}
                  onChange={handleChange('clpassword')}
                />
                <Form.Text className='text-muted'>Придумайте надежный пароль</Form.Text>
              </Form.Group>
              <Form.Group className='mb-3' controlId='formRetypePassword'>
                <Form.Label>Повторите пароль</Form.Label>
                <Form.Control
                  required
                  type='password'
                  placeholder='Повторите пароль'
                  value={values.passwordcheck}
                  onChange={handleChange('passwordcheck')}
                />
              </Form.Group>
              {/* <Form.Group className='mb-3' controlId='formBasicCheckbox'>
                <Form.Check type='checkbox' label='Запомнить меня' />
              </Form.Group> */}
            </Form>
            <div className='small my-4 text-center'>
              <Button variant='primary' className='mt-4 text-center ' onClick={onClick}>
                Зарегистрироваться
              </Button>
            </div>
            <p className='small my-4 text-center mt-4'>
              Есть аккаунт? <Link to={Links.auth}>Авторизируйтесь</Link>
            </p>
          </div>
        </Col>
      </Row>
    </Container>
  );
}
