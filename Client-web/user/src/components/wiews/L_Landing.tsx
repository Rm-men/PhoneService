import React from 'react';
import LHeader from '../landing/LHeader';
import LFeatures from '../landing/LFeatures';
import LBlogPosts from '../landing/LBlogPosts';
import LCTA from '../landing/LCTA';
import L_Navibar from '../usercabinet/auth_Navibar';
import Footer from '../other/Footer';



export default class L_Landing extends React.Component {
  render() {
    return (
      <div className="landing">
        <L_Navibar/> 
        <LHeader />
        <Footer/>
      </div>
    );
  };
};
