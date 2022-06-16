import React from 'react';
import L_Navibar from '../usercabinet/auth_Navibar';
import { Button, Nav, Navbar, Table, Container, Row, Form, Col } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import FormNewOrder from '../newOrder/FormNewOrder';

export default function NewOrder() {
  return (
    <>
      <L_Navibar />
      <div className='header bg-white mt-5'>
        <Container>
          <h1 className='display-4'>Оформление новой заявки</h1>
          <Form className='form-subscribe form-inline mb-3'>
            <FormNewOrder></FormNewOrder>
            {/* <div className='text-center'>
              <Button type='submit' color='primary' size='lg' className='.text-center mt-3'>
                Оформить заявку на ремонт
              </Button>
            </div> */}
          </Form>
        </Container>
      </div>
    </>
  );
}
