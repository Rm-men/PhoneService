import React from 'react';

import { Button, Container, Form, FormLabel, InputGroup, Row, Col } from 'react-bootstrap';
export default function LForm() {
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
                <Form.Control type='email' placeholder='Введите email' />
                {/* <Form.Text className='text-muted'>
            We'll never share your email with anyone else.
          </Form.Text> */}
              </Form.Group>

              <Form.Group className='mb-3' controlId='formBasicPassword'>
                <Form.Label>Пароль</Form.Label>
                <Form.Control type='password' placeholder='Введите пароль' />
              </Form.Group>
              <Form.Group className='mb-3' controlId='formBasicCheckbox'>
                <Form.Check type='checkbox' label='Запомнить меня' />
              </Form.Group>
              <Button variant='primary' type='submit'>
                Войти
              </Button>
            </Form>
            <p className='small my-4 text-center'>
              Нет аккаунта? <a href='#a'>Зарегистрируйтесь</a>
            </p>
          </div>
        </Col>
      </Row>
    </Container>
  );
}
