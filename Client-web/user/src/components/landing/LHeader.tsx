import React from 'react';
import {
  Container,
  Row,
  Col,
  Form,
  FormGroup,
  Button
} from 'react-bootstrap';
import devices from './../../assets/img/landing_devices.png';

const LHeader = () => {
  return (
    <div className="header bg-white mt-5">
    	<Container>
		{/* <h1 className="display-1 opacity-0">0</h1> */}
    		<Row>
    			<Col xs="12" md="6">
    				<h1 className="display-4">Ремонт телефонов в Кирове от <b>400р</b></h1>
    		    <Form className="form-subscribe form-inline mb-3">
    		        {/* <FormGroup className="flex-grow-1">
    		          <Label className="sr-only" for="email4">Email</Label>
    		          <Input type="text" bsSize="lg" className="flex-grow-1 mr-2" id="email4" placeholder="Your email address..." />
    		        </FormGroup> */}
							{/* <h1 className="display-6 opacity-0">0</h1> */}
    		        <Button type="submit" color="primary" size="lg" className=" mt-4">Оставить заявку на ремонт</Button>
    		    </Form>
    			</Col>
    			<Col xs="12" md="6">
    				<div className="devices ">
    					<img src={devices} alt="devices" className="img-fluid" />
    				</div>
    			</Col>
    		</Row>
    	</Container>
    </div>
  );
};

export default LHeader;
