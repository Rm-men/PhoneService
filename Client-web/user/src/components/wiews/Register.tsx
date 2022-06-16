import React from 'react';
import {
  Container,
  Row,
  Col
} from 'reactstrap';
import RNavbar from '../auth/RNavbar';
import RForm from '../auth/RForm';

class Register extends React.Component {
  render() {
    return (
        <div className="register">
          <Container fluid={true} >
                <RForm />
          </Container>
        </div>
    );
  };
};

export default Register;
