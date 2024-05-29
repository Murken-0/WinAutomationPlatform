<template>
	<div class="navbar">
		<my-button @click="$router.push('/')">
			<div>Платформа</div>
			<div>роботизации</div>
		</my-button>
		<div class="navbar__btns">
			<my-button style="margin-left: 15px" @click="$router.push('/workflows/')">Процессы</my-button>
			<my-button style="margin-left: 15px" @click="$router.push('/tasks/')">Задачи</my-button>
		</div>
	</div>
</template>

<script>
import MyButton from "@/components/UI/MyButton.vue";

export default {
	components: {MyButton}

}
</script>

<style scoped>
.navbar {
	height: 70px;
	background-color: lightgray;
	box-shadow: 0px 1px 3px gray;
	display: flex;
	align-items: center;
	padding: 0px 20px;
}

.navbar__btns {
	margin-left: auto;
}

</style>