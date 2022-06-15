import Modal from 'react-bootstrap/Modal';
import React, { useState } from 'react';
import { Alert, Button } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import { Link } from 'react-router-dom';
import UserCabinet from './UserCabinet';

export default function Alert_update() {

    const [show, setShow] = useState(true);

    if (show) {
      return (
        <Alert variant="success" onClose={() => setShow(false)} dismissible>
          <Alert.Heading>Изменение статуса</Alert.Heading>
          <p>
            У заказа ремонта устройства -name- статус изменен на -status- 
          </p>
        </Alert>
      );
    }
    return <Button onClick={() => setShow(true)}>*Обновилась таблица*</Button>;
}

