import 'react-app-polyfill/ie11';
import { Button, Container, FormLabel, InputGroup, Row, Col, Form } from 'react-bootstrap';

import React, { useState } from 'react';
import * as ReactDOM from 'react-dom';
import { Formik, Field, FormikHelpers } from 'formik';

export default function FormExample() {
  const [validated, setValidated] = useState(false);

  const handleSubmit = (event) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    }
    setValidated(true);
  };

  return (
    <Form noValidate validated={validated} onSubmit={handleSubmit}>
      <Row className='mb-3'>
        <Form.Group as={Col} md='4' controlId='validationCustom02'>
          <Form.Label>Фамилия</Form.Label>
          <Form.Control required type='text' placeholder='Введите фамилию' />
          <Form.Control.Feedback></Form.Control.Feedback>
        </Form.Group>
        <Form.Group as={Col} md='4' controlId='validationCustom01'>
          <Form.Label>Имя</Form.Label>
          <Form.Control required type='text' placeholder='Введите имя' defaultValue='' />
          <Form.Control.Feedback></Form.Control.Feedback>
        </Form.Group>
        <Form.Group as={Col} md='4' controlId='validationCustom01'>
          <Form.Label>Отчество</Form.Label>
          <Form.Control
            required
            type='text'
            placeholder='Введите отчество (если есть)'
            defaultValue=''
          />
          <Form.Control.Feedback></Form.Control.Feedback>
        </Form.Group>
        <Form.Group as={Col} md='4' controlId='validationCustomUsername'>
          <Form.Label>Номер телефона</Form.Label>
          <InputGroup hasValidation>
            <InputGroup.Text id='inputGroupPrepend'>+7</InputGroup.Text>
            <Form.Control
              // type='number' появляются стрелочки для изменения числа, для номера оно не надо
              placeholder='Введите Email'
              aria-describedby='inputGroupPrepend'
              required
            />
            <Form.Control.Feedback type='invalid'>
              Пожалуйста, введите ваш номер телефона
            </Form.Control.Feedback>
          </InputGroup>
        </Form.Group>
      </Row>
      <Form.Group as={Col} md='4' controlId='validationCustomUsername'>
        <Form.Label>Email</Form.Label>
        <InputGroup hasValidation>
          <InputGroup.Text id='inputGroupPrepend'>@</InputGroup.Text>
          <Form.Control
            type='email'
            placeholder='Введите Email'
            aria-describedby='inputGroupPrepend'
            required
          />
          <Form.Control.Feedback type='invalid'>
            Пожалуйста, введите ваш Email
          </Form.Control.Feedback>
        </InputGroup>
      </Form.Group>
      <Row className='mb-3'>
        <Form.Group as={Col} md='3' controlId='validationCustom04'>
          <Form.Label>Пароль</Form.Label>
          <Form.Control type='password' placeholder='Введите пароль' required />
          <Form.Control.Feedback type='invalid'>Пожалуйста, введите пароль</Form.Control.Feedback>
        </Form.Group>
        <Form.Group as={Col} md='3' controlId='validationCustom05'>
          <Form.Label>Повторите пароль</Form.Label>
          <Form.Control type='password' placeholder='Введите пароль повторно' required />
          <Form.Control.Feedback type='invalid'>
            Пожалуйста, повторите введеный пароль.
          </Form.Control.Feedback>
        </Form.Group>
      </Row>
      <Form.Group className='mb-3'>
        {/* <Form.Check
          required
          label="Agree to terms and conditions"
          feedback="You must agree before submitting."
          feedbackType="invalid"
        /> */}
      </Form.Group>
      <Button type='submit'>Зарегистрироваться</Button>
    </Form>
  );
}
