import React from 'react';
import {
  Button,
  Container
} from "reactstrap";
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import { faVk, faGithub, faNodeJs} from '@fortawesome/free-brands-svg-icons';
import { faMugHot} from '@fortawesome/free-solid-svg-icons';

const Footer = (props) => {
  return (
    <footer className="footer-1 bg-light text-dark">
      <Container>
      <div className="d-flex flex-column flex-md-row justify-content-between align-items-center">
      	<div className="links">
      		<ul className="footer-menu list-unstyled d-flex flex-row text-center text-md-left">
      			{/* <li><a href="https://bootstrapbay.com/" target="_blank" rel="noopener noreferrer">Store</a></li>
      			<li><a href="https://bootstrapbay.com/about" target="_blank" rel="noopener noreferrer">About Us</a></li>
      			<li><a href="https://bootstrapbay.com/blog/" target="_blank" rel="noopener noreferrer">Blog</a></li>
      			<li><a href="https://bootstrapbay.com/terms" target="_blank" rel="noopener noreferrer">Terms & Conditions</a></li> */}
      		</ul>
      	</div>
      	<div className="social mt-4 mt-md-0">
          <Button color="secondary" outline className="btn-icon" href="https://vk.com/rm_men" target="_blank">
          <FontAwesomeIcon icon={faVk} />
          </Button>
          {" "}
          <Button color="secondary" outline className="btn-icon" href="https://github.com/Rm-men/PhoneService" target="_blank">
          <FontAwesomeIcon icon={faGithub} />
          </Button>
          {" "}
        </div>
      </div>
      <div className="copyright text-center">
      	<hr />
      	<p className="small"> 2022, сделано с помощью
          <span className="text-danger">
            {" "}<FontAwesomeIcon icon={faMugHot} />{" "}
          </span>
          {/* <span className="text-success">
            {" "}<FontAwesomeIcon icon={faNodeJs} />{" "}
          </span> */}
          by React-Bootstrap
        </p>
      </div>
      </Container>
    </footer>
  );
};

export default Footer;
