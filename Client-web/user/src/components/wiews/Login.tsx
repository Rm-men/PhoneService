import React from 'react';
import {
  Container,
  Row,
  Col
} from 'reactstrap';
import RNavbar from '../auth/RNavbar';
import LForm from '../auth/LForm';

export default class Login extends React.Component {
  render() {
    return (
        <div className="register ">
          <RNavbar />
          <Container fluid={true} >
                <LForm />
          </Container>
        </div>
    );
  };
};
