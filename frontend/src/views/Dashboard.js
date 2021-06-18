import React, { useState, useEffect } from 'react'
import { makeStyles } from '@material-ui/core/styles'
import { useHistory } from 'react-router-dom'
import Container from '@material-ui/core/Container'
import Paper from '@material-ui/core/Paper'
import Grid from '@material-ui/core/Grid'
import { toast } from 'react-toastify'
import Button from '@material-ui/core/Button'
import CircularProgress from '@material-ui/core/CircularProgress'
import Grow from '@material-ui/core/Grow'
import { DropzoneArea } from 'material-ui-dropzone'
import PublishIcon from '@material-ui/icons/Publish'
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
    backgroundColor: '#000',
    padding: theme.spacing(2),
    marginBottom: theme.spacing(1),
    marginTop: theme.spacing(6),
    textAlign: 'center',
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
    color: '#000',
    padding: '0.5rem',
    marginBottom: theme.spacing(2),
    margin: 'auto',
    width: '1.5rem',
  },
  space: {
    paddingTop: '1.5rem',
    paddingBottom: '1.5rem',
    fontSize: '0.8rem',
    textAlign: 'center',
  },
  login: {
    padding: 6,
  },
  btn: {
    marginTop: theme.spacing(2),
  },
  icon: {
    padding: 3,
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

export default function Dashboard() {
  document.title = 'Dashboard'
  const history = useHistory()
  const user = JSON.parse(localStorage.getItem('UserData'))
  const config = {
    headers: {
      Authorization: `Bearer ${user && user.token}`,
      'Content-Type': 'application/json',
    },
  }
  const classes = useStyles()
  const [file, setFile] = useState({})
  const [buttonLoading, setButtonLoading] = useState(() => false)

  const uploadFile = () => {
    setButtonLoading(true)
    if (file) {
      const isRefFile = file.name.split('.')[1].includes('ref')
      const formData = new FormData()
      formData.append('file', file)
      axios
        .post('/api/upload', formData, config)
        .then((res) => {
          if (res.status === 200) {
            localStorage.setItem('FileName', JSON.stringify(file.name))
            AlertSuccess('Your file is uploaded.')
            if (isRefFile) history.push('/assemble')
            else history.push('/shred')
          }
        })
        .catch((error) => AlertError(`${error.response.status} error occured.`))
    } else {
      setTimeout(() => {
        setButtonLoading(false)
        AlertWarning('Upload a file.')
      }, 1000)
    }
  }

  useEffect(() => {
    if (!user) history.push('/login')
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  return (
    <Grow direction="up" in={true}>
      <Container className={classes.root}>
        <Grid justify="center" container spacing={2}>
          <Grid item xs={12} lg={10} md={8}>
            <Paper className={classes.paper} elevation={20}>
              <DropzoneArea
                fullWidth={true}
                showFileNames={true}
                filesLimit={1}
                dropzoneText="Drag and drop a file to shred or ref file to assemble"
                onChange={(files) => {
                  setFile(files[0])
                }}
              />
              <Button
                fullWidth
                variant="contained"
                color="secondary"
                className={classes.btn}
                onClick={() => uploadFile()}
              >
                {buttonLoading ? (
                  <CircularProgress
                    className={classes.icon}
                    size={24}
                    color="inherit"
                  />
                ) : (
                  <PublishIcon className={classes.icon} />
                )}
              </Button>
            </Paper>
          </Grid>
        </Grid>
      </Container>
    </Grow>
  )
}
