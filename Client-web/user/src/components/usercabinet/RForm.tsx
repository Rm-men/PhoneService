import React from 'react';
import { Button, Container, Form, FormLabel, InputGroup, Row, Col } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export default function RForm() {
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
              <Form.Group className='mb-3' controlId='formBasicEmail'>
                <Form.Label>Email </Form.Label>
                <Form.Control type='email' placeholder='Введите email' />
                {/* <Form.Text className='text-muted'>
            We'll never share your email with anyone else.
          </Form.Text> */}
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPassword'>
                <Form.Label>Пароль</Form.Label>
                <Form.Control type='password' placeholder='Введите пароль' />
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicPassword'>
                <Form.Label>Повторите пароль</Form.Label>
                <Form.Control type='password' placeholder='Повторите пароль' />
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicCheckbox'>
                <Form.Check type='checkbox' label='Запомнить меня' />
              </Form.Group>
              <Link to="home">
                <Button variant='primary' type='submit'>
                  Зарегистрироваться
                </Button>
              </Link>
            </Form>
            <p className='small my-4 text-center'>
              Есть аккаунт? <a href='/login'>Авторизируйтесь</a>
            </p>
          </div>
        </Col>
      </Row>
    </Container>
  );
}
