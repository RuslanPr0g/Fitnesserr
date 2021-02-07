import Link from "next/link";
import Head from "next/head";
import Layout from "../../components/layout";

export default function Exercises(props: object) {
  let exercisesList = () => 
    props.exercises.map((exercise: object, index: number) => <li key={index}>{exercise.name}</li> );

  return (
    <Layout home="/">
      <Head>
        <title>Exercises</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <ul>
        { exercisesList() }
      </ul>
    </Layout>
  );
}

export async function getStaticProps() {
  const https = require("https");
  const url = 'https://localhost:44334/api/exercises';
  const agent = new https.Agent({
    rejectUnauthorized: false
  })

  const res = await fetch(url, { agent })

  const exercises = await res.json()

  return {
    props: {
      exercises: exercises,
    },
  }
}