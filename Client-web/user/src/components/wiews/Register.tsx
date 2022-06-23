import React from 'react';
import {
  Container,
  Row,
  Col
} from 'reactstrap';
import RNavbar from '../auth/RNavbar';
import RForm from '../auth/RForm';
import RForm2 from '../auth/RForm2';

class Register extends React.Component {
  render() {
    return (
        <div className="register mt-4">
          <Container fluid={true} >
                <RForm />
          </Container>
        </div>
    );
  };
};

export default Register;
