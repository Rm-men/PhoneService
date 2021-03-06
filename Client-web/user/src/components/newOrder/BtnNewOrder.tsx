import { Container, Form, Button, Modal, Card, InputGroup} from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom'; 
import React, { useState } from 'react';
import Links from '../Links';
import { AppDispatch, RootState } from '../../redux/store';
import { useDispatch, useSelector } from 'react-redux';
import { NewOrderModel } from '../../models/NewOrderModel';
import ServAddOrder from '../../redux/services/ServAddOrder';
import ServGetLists from '../../redux/services/ServGetLists';
import { AddressModel } from '../../models/AddressModel';
import { PhonesModel } from '../../models/PhonesModel';

export default function BtnNewOrder() {
  const [addresses, setAdresses] = useState<AddressModel[]>([]);
  const [phones, setPhones] = useState<PhonesModel[]>([]);
  const [addres, setAddres] = useState<string>('');
  const [phone, setPhone] = useState<string>('');
  const [curphone, setCurPhone] = useState<PhonesModel>();
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const openNewOrderModal = () => {
    setShow(true);
    ServGetLists.getPhones().then((res: any) => {
      console.log(res);
      setPhones(res);
    });
  };
  const user = useSelector((state: RootState) => state);
  const managerModal = () => {};
  const handleChange = (prop: keyof State) => (event: React.ChangeEvent<HTMLInputElement>) => {
    setValues({ ...values, [prop]: event.target.value});
  };
  interface State {
    Phonenumber: string;
    Address: string;
    IdPhone: number;
    Descriptionord: string;
    Namephone: string,
  }
  const [values, setValues] = useState<State>({
    Phonenumber: '',
    Address: 'Ул. Московская 36',
    IdPhone: 1,
    Descriptionord: ' ',
    Namephone: 'Ноутилус ++',
  });
  const [validated, setValidated] = useState(false);
  const toCreateNewOrder = (event: any) => {
    const form = event.currentTarget;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
      return;
    } else setValidated(true); 
    if (
      values.Phonenumber === '' ||
      values.Address === '' ||
      values.Descriptionord === ''
    ) {
      console.log('' + 'не');
      return;
    }
    const data: NewOrderModel = {
      Phonenumber: values.Phonenumber,
      Address: values.Address,
      IdPhone: values.IdPhone,
      Namephone: values.Namephone,
      Descriptionord: values.Descriptionord,
      Email: user.client.client?.Email!,
    };
    console.log(data);
    ServAddOrder.order(data).then((res) => {
      handleClose();
      navigate(0);
    });
  };
  const navigate = useNavigate();
  const dispatch = useDispatch<AppDispatch>();
  const [key, setKey] = useState<boolean>(false); 

  React.useEffect(() => {
    if (key) return;
    setKey(true);
  }, [addres, key]);

  return (
    <>
      <Button color='primary' size='lg' className=' mt-4' onClick={openNewOrderModal}>
        Оставить заявку на ремонт
      </Button>

      {user.client.isAuth ? (
        <>
          <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
              <Modal.Title>Оформление заявки</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              <Container>
                <Card className='no-hover'>
                  <Card.Body className='p-5'>
                    <Form noValidate validated={validated}>
                      <Form.Group className='mb-3' controlId='formBasicName'>
                        <Form.Label>Название устройства </Form.Label>
                        <Form.Select
                          placeholder='Введите название устройства'
                          required
                          value={phone}
                          onChange={(e) => {
                            values.Namephone = e.target.value;
                            setPhone( e.target.value)
                          }}
                        >
                          {phones?.map((phones) => (
                            <option value={phones.Namephone}>{phones.Namephone}</option>
                          ))}
                        </Form.Select>
                      </Form.Group>

                      <Form.Group controlId='formBasicPhNumb'>
                        <Form.Label>Номер телефона</Form.Label>
                        <InputGroup hasValidation>
                          <InputGroup.Text id='inputGroupPrepend'>+7</InputGroup.Text>
                          <Form.Control
                            placeholder='Введите номер телефона'
                            required
                            value={values.Phonenumber}
                            onChange={handleChange('Phonenumber')}
                          />
                          <Form.Text className='text-muted'>
                            Введите номер телефона, на который придет сообщение о готовности
                          </Form.Text>
                        </InputGroup>
                      </Form.Group>
                    </Form>
                    <Form noValidate validated={validated}>
                      <Form.Group className='mb-3' controlId='exampleForm.ControlTextarea1'>
                        <Form.Label>Введите описание неисправности</Form.Label>
                        <Form.Control
                          required
                          as='textarea'
                          rows={3}
                          value={values.Descriptionord}
                          onChange={handleChange('Descriptionord')}
                        />
                      </Form.Group>
                      <div className='text-center mt-5'>
                        <Button
                          variant='secondary'
                          size='lg'
                          className='me-2'
                          onClick={handleClose}
                        >
                          Отмена
                        </Button>
                        <Button color='primary' size='lg' onClick={toCreateNewOrder}>
                          Оформить заявку
                        </Button>
                      </div>
                    </Form>
                  </Card.Body>
                </Card>
              </Container>
            </Modal.Body>
          </Modal>
        </>
      ) : (
        <>
          <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
              <Modal.Title>Предупреждение</Modal.Title>
            </Modal.Header>
            <Modal.Body>
              Заявки на ремонт доступны <b>только зарегистрированным</b> пользователям.
              Авторизироваться?
            </Modal.Body>
            <Modal.Footer>
              <Button variant='secondary' onClick={handleClose}>
                Отмена
              </Button>
              <Link to={Links.auth}>
                <Button variant='primary' onClick={handleClose}>
                  Авторизироваться
                </Button>
              </Link>
            </Modal.Footer>
          </Modal>
        </>
      )}
    </>
  );
}
