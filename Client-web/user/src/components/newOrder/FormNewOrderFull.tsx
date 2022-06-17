import React from 'react';
import { Container, Row, Col, Card, CardBody, FormGroup, Label, Input, Button } from 'reactstrap';
import { Dropdown, DropdownButton, Form } from 'react-bootstrap';

const FormNewOrderFull = () => {
  return (
    <div className='contact mt-4'>
      {/* <div className="cta bg-primary text-center text-white">
        <h1 className="text-white">Связаться с нами</h1>
        <p className="lead">Дайте нам знать, что вы думаете. Мы свяжемся с вами в течение дня.</p>
      </div> */}
      <div>
        <Container>
              <Card className='no-hover'>
                <CardBody className='p-5'>
                  <Form>
                    <FormGroup>
                      <Label>Название устройства</Label>
                      <Input type='text' bsSize='lg' placeholder='Введите название устройства' />
                    </FormGroup>
                      <Form.Group className='mb-3'>
                        <Form.Label>Выберите пункт приема</Form.Label>
                        <Form.Select>
                          <option>Ул. Московская 36</option>
                          <option>???</option>
                        </Form.Select>
                      </Form.Group>
                    <FormGroup>
                      <Label>Введите описание неисправности</Label>
                      <Input type='textarea' rows='5'></Input>
                    </FormGroup>
                    <div className='text-center mt-5'>
                      <Button type='submit' color='secondary' size='lg' className='me-2'>
                        Отмена
                      </Button>
                      <Button type='submit' color='primary' size='lg'>
                        Оформить заявку
                      </Button>
                    </div>
                  </Form>
                </CardBody>
              </Card>
        </Container>
      </div>
    </div>
  );
};

export default FormNewOrderFull;
