import React from 'react';
import {
  Container,
  Row,
  Col
} from 'reactstrap';
import RNavbar from '../RNavbar';
import LForm from '../usercabinet/LForm';

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
