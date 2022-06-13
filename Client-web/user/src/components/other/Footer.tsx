import React from 'react';
import {
  Button,
  Container
} from "reactstrap";
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import { faVk} from '@fortawesome/free-brands-svg-icons';

const Footer = (props) => {
  return (
    <footer className="footer-1 bg-light text-dark">
      <Container>
      <div className="d-flex flex-column flex-md-row justify-content-between align-items-center">
      	<div className="links">
      		<ul className="footer-menu list-unstyled d-flex flex-row text-center text-md-left">
      			<li><a href="https://bootstrapbay.com/" target="_blank" rel="noopener noreferrer">Store</a></li>
      			<li><a href="https://bootstrapbay.com/about" target="_blank" rel="noopener noreferrer">About Us</a></li>
      			<li><a href="https://bootstrapbay.com/blog/" target="_blank" rel="noopener noreferrer">Blog</a></li>
      			<li><a href="https://bootstrapbay.com/terms" target="_blank" rel="noopener noreferrer">Terms & Conditions</a></li>
      		</ul>
      	</div>
      	<div className="social mt-4 mt-md-0">
          <Button color="primary" outline className="twitter btn-icon" href="https://twitter.com/" target="_blank">
          <FontAwesomeIcon icon={faVk} />
          </Button>
          {" "}
          <Button color="primary" outline className="facebook btn-icon" href="https://www.facebook.com/" target="_blank">
            <FontAwesomeIcon icon={['fab', 'facebook-square']}  className='text-secondary'/> {" "}
            <i className='bi-facebook text-secondary' style={{ fontSize: 20 }}></i>
          </Button>
          {" "}
          <Button color="primary" outline className="github btn-icon" href="https://github.com/bootstrapbay" target="_blank">
          <i className='bi-github text-secondary' style={{ fontSize: 20 }}></i>
          </Button>
        </div>
      </div>
      <div className="copyright text-center">
      	<hr />
      	<p className="small">&copy; 2019, made with
          <span className="text-danger">
            {" "}<FontAwesomeIcon icon="heart" />{" "}
          </span>
          by BootstrapBay
        </p>
      </div>
      </Container>
    </footer>
  );
};

export default Footer;
