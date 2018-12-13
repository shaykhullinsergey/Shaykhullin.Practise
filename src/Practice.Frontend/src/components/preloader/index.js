import React from 'react'
import { render } from 'react-dom'
import { Dots } from 'react-preloaders'

export class Preloader {
  static show() {
    const preloader = document.getElementById('preloader');

    preloader.innerHTML = '';
    preloader.style.display = 'block';

    render(<Dots time={9999999999}/>, preloader);
  }

  static hide() {
    document.getElementById('preloader').style.display = 'none';
  }
}