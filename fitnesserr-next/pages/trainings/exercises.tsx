import Link from "next/link";
import Head from "next/head";
import Layout from "../../components/layout";
import { IExerciseList } from "./IExerciseList";
import { IExercise } from "./IExercise";

export default function Exercises(props: IExerciseList) {
  let exercisesList = () => 
    props.exercises.map((exercise: IExercise, index: number) => <li key={index} className={"listing_item"}>
      <h1>Name: {exercise.name}</h1>
      <h2>Description: {exercise.description}</h2>
      <h3>Order: {exercise.order}</h3>
      <h3>Time to complete: {exercise.timeToComplete}</h3>
      <h3>Times: {exercise.times}</h3>
      </li>);

  return (
    <Layout home="/">
      <Head>
        <title>Exercises</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>

      <ul className="listing">
        { exercisesList() }
      </ul>
    </Layout>
  );
}

export async function getStaticProps() {
  const https = require("https");
  const url = 'https://localhost:44334/api/exercises';
  const agent : RequestInit = new https.Agent({
    rejectUnauthorized: false
  })

  const res = await fetch(url, { agent } as RequestInit)

  const exercises: IExerciseList = await res.json()

  return {
    props: {
      exercises: exercises,
    },
  }
}
