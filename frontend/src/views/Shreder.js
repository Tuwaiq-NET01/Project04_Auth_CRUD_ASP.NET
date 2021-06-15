import React, { useEffect, useState } from 'react'
import Loader from '../components/Loader'

export default function Shreder() {
  const [loading, setLoading] = useState(() => true)
  useEffect(() => {
    console.log(localStorage.getItem('file'))
    setTimeout(() => setLoading(false), 2000)
  })
  return <div>{loading ? <Loader /> : <h2>Shreder</h2>}</div>
}
