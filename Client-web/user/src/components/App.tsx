import React from 'react';
import UserCabinet from './wiews/UserCabinet';
import Landing from './wiews/Landing';
import Navibar from './usercabinet/auth_Navibar';
import { Route, Router, Routes} from 'react-router-dom';
function App () {
    return (
      <>
      <Navibar/>
      <Routes>
        <Route path='/home' element={Landing}/>
        <Route path='/usercabinet' element={UserCabinet}/>
      </Routes>
    </>
    )
  }
export default App;