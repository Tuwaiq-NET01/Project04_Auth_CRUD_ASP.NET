import React, { useEffect, useState } from 'react'
import { makeStyles } from '@material-ui/core/styles'
import { useHistory } from 'react-router-dom'
import { toast } from 'react-toastify'
import Container from '@material-ui/core/Container'
import Paper from '@material-ui/core/Paper'
import Grid from '@material-ui/core/Grid'
import CircularProgress from '@material-ui/core/CircularProgress'
import VpnKeyIcon from '@material-ui/icons/VpnKey'
import CloseIcon from '@material-ui/icons/Close'
import Button from '@material-ui/core/Button'
import TextField from '@material-ui/core/TextField'
import Typography from '@material-ui/core/Typography'
import Grow from '@material-ui/core/Grow'
import axios from 'axios'

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  rootForm: {
    '& > *': {
      margin: theme.spacing(1),
      width: '75%',
    },
  },
  paper: {
    padding: theme.spacing(2),
    marginBottom: theme.spacing(1),
    marginTop: theme.spacing(6),
    textAlign: 'center',
    color: theme.palette.text.secondary,
    borderRadius: theme.spacing(2),
  },
  large: {
    width: theme.spacing(23),
    height: theme.spacing(8),
    padding: theme.spacing(4),
    margin: 'auto',
  },
  divider: {
    borderBottom: 'solid',
    borderWidth: '1px',
    color: '#ff5722',
    padding: '0.5rem',
    marginBottom: '2rem',
    margin: 'auto',
    width: '1.5rem',
  },
  space: {
    paddingTop: '1.5rem',
    paddingBottom: '1.5rem',
    fontSize: '0.8rem',
    textAlign: 'center',
  },
  icon: {
    paddingTop: 10,
    paddingBottom: 10,
  },
  btn: {
    marginTop: theme.spacing(1),
  },
  infoBlock: {
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
  },
  infoText: {
    marginTop: theme.spacing(2),
    color: '#32CD32',
    fontSize: '1.5rem',
  },
  cnkChild: {
    width: 50,
    height: 50,
    paddingRight: 200,
  },
  cnkParent: {
    width: '95%',
    height: 100,
    textAlign: 'center',
    display: 'block',
  },
  cnkText: {
    marginTop: theme.spacing(2),
    color: '#32CD32',
    fontSize: '0.9rem',
  },
}))

const AlertSuccess = (msg) => {
  toast.success(`🚀 ${msg}`, {
    position: 'top-right',
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

const AlertError = (msg) => {
  toast.error(`💩 ${msg}`, {
    position: 'top-right',
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

const AlertInfo = (msg) => {
  toast.info(`✌ ${msg}`, {
    position: 'top-right',
    autoClose: 1500,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

const AlertWarning = (msg) => {
  toast.warn(`⛔ ${msg}`, {
    position: 'top-right',
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

export default function Assembler() {
  document.title = 'Assembler'
  const user = JSON.parse(localStorage.getItem('UserData'))
  const config = {
    headers: {
      Authorization: `Bearer ${user && user.token}`,
      'Content-Type': 'application/json',
    },
  }
  const history = useHistory()
  const fileName = JSON.parse(localStorage.getItem('FileName'))
  const classes = useStyles()
  const [buttonLoading, setButtonLoading] = useState(() => false)
  const [chunksPassword, setChunksPassword] = useState(() => '')

  const assemble = () => {
    setButtonLoading(true)
    if (chunksPassword.length <= 1) {
      setButtonLoading(false)
      AlertError(`Check your AES-256 Key.`)
      return
    }
    axios
      .post(
        `/api/chunk/reassemble/${fileName}`,
        { chunksPassword: chunksPassword },
        {
          ...config,
          responseType: 'blob',
        }
      )
      .then((res) => {
        const contentDisposition = res.headers['content-disposition']
        const downloadName = contentDisposition.split(';')[1].split('=')[1]
        const url = window.URL.createObjectURL(
          new File([res.data], downloadName)
        )
        const link = document.createElement('a')
        link.href = url
        link.setAttribute('download', downloadName)
        document.body.appendChild(link)
        link.click()
        link.parentNode.removeChild(link)
        AlertSuccess(`Reassembling complete.`)
        history.push('/')
      })
      .catch((error) => {
        history.push('/')
        AlertWarning(`The file has been assembled.`)
      })
  }

  useEffect(() => {
    if (!user) history.push('/login')
    else if (!fileName) {
      history.push('/')
      AlertInfo('Upload a ref file to assemble.')
    }

    return () => {
      if (fileName) {
        localStorage.setItem('FileName', null)
      }
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])
  return (
    <Grow direction="up" in={true}>
      <Container className={classes.root}>
        <Grid justify="center" container spacing={2}>
          <Grid item xs={12} lg={10} md={8}>
            <Paper className={classes.paper} elevation={20}>
              <Typography color="secondary" variant="h5" nowrap="true">
                {'Assemble: '}
                <span style={{ color: '#000' }}>{fileName}</span>
              </Typography>
              <div className={classes.divider} />
              <Grid container justify="center" spacing={2}>
                <Grid item xs={10}>
                  <TextField
                    fullWidth
                    label="AES-256 Key"
                    type="password"
                    variant="filled"
                    color="secondary"
                    defaultValue={chunksPassword.password}
                    onChange={(e) => setChunksPassword(e.target.value)}
                  />
                </Grid>
                <Grid item xs={2}>
                  <Button
                    fullWidth
                    variant="contained"
                    style={{
                      backgroundColor: '#32CD32',
                    }}
                    onClick={() => assemble()}
                  >
                    {buttonLoading ? (
                      <CircularProgress
                        className={classes.icon}
                        size={24}
                        color="inherit"
                      />
                    ) : (
                      <VpnKeyIcon className={classes.icon} />
                    )}
                  </Button>
                </Grid>
                <Grid item xs={12}>
                  <Button
                    fullWidth
                    variant="contained"
                    color="primary"
                    className={classes.btn}
                    onClick={() => {
                      history.push('/')
                    }}
                  >
                    <CloseIcon className={classes.icon} />
                  </Button>
                </Grid>
              </Grid>
            </Paper>
          </Grid>
        </Grid>
      </Container>
    </Grow>
  )
}
