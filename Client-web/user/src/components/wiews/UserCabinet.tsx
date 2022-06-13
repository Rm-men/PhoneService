import React from 'react';
import L_Navibar from '../usercabinet/auth_Navibar';
import { Button, Nav, Navbar, Table, Container, Row, Form, Col } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

export default function UserCabinet() {
  return (
    <>
      <L_Navibar />

      <div className='header bg-white mt-5'>
        <Container>
          <h1 className='display-4'>Список устройств в ремонте</h1>
          <Container>
          <Table striped bordered hover>
            <thead>
              <tr>
                <th>#</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Username</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>1</td>
                <td>Mark</td>
                <td>Otto</td>
                <td>@mdo</td>
              </tr>
              <tr>
                <td>2</td>
                <td>Jacob</td>
                <td>Thornton</td>
                <td>@fat</td>
              </tr>
              <tr>
                <td>3</td>
                <td colSpan={2}>Larry the Bird</td>
                <td>@twitter</td>
              </tr>
            </tbody>
          </Table>
        </Container>
          <Form className='form-subscribe form-inline mb-3'>
            <div className='text-center'>
              <Button type='submit' color='primary' size='lg' className='.text-center mt-3'>
                Оформить заявку на ремонт
              </Button>
            </div>
          </Form>
        </Container>
      </div>
    </>
  );
}
