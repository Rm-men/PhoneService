import React from 'react';
import {
  Container,
  Row,
  Col,
  Button,
  Collapse,
  Navbar,
  NavbarToggler,
  Nav,
  NavItem
} from 'reactstrap';
import { NavLink } from 'react-router-dom';

class RNavbar extends React.Component {
    // constructor(props) {
    //   super(props);
    //   this.toggle = this.toggle.bind(this);
    //   this.state = {
    //     isOpen: false
    //   };
    // }

    // toggle () {
    //   this.setState({
    //     isOpen: !this.state.isOpen
    //   });
    // }

    render() {
      return (
        <div>
          <Navbar className="navbar-transparent" light expand="md">
            <Container fluid={true}>
              <Row>
                <Col xs="12" md={{size: 2, offset: 1}} className="d-flex justify-content-between">
                  {/* <NavbarToggler onClick={this.toggle} /> */}
                  <NavbarToggler />
                </Col>
                <Col xs="12" md={{size: 5, offset: 3}} className="d-flex justify-content-end text-center">
                {/* <Collapse isOpen={this.state.isOpen} navbar> */}
                </Col>
              </Row>
            </Container>
          </Navbar>
        </div>
      );
    }
};

export default RNavbar;
