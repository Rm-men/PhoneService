import React, {useState, useRef} from 'react';

import PhoneInput from 'react-phone-input-2'
import 'react-phone-input-2/lib/style.css'

export default function Page__REGISTER() {

  const [phoneNumber, setPhoneNumber] = useState<''>();

  const phoneInput = useRef(null);

  const getPhoneNumber = () => {
    alert(phoneNumber);
  };

  return (
    <>
          <PhoneInput onClick={getPhoneNumber}
        country="ru"
        value={phoneNumber}
        // inputProps = {phoneNumber}
        // onChange={phoneNumber => {
        //   setPhoneNumber("1");
        // }}
      />
      <div></div>
    </>
  );
};