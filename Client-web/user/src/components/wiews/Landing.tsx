import React from 'react';
import LHeader from './../landing/LHeader';
import LFeatures from './../landing/LFeatures';
import LBlogPosts from './../landing/LBlogPosts';
import LCTA from './../landing/LCTA';
import LNavbar from '../landing/LNavbar';
import Footer from '../other/Footer';


class Landing extends React.Component {
  render() {
    return (
      <div className="landing">
        <LHeader />
        <Footer/>
      </div>
    );
  };
};

export default Landing;
